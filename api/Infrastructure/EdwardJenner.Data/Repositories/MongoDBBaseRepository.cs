using System;
using System.Diagnostics;
using EdwardJenner.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;

namespace EdwardJenner.Data.Repositories
{
    public class MongoDbBaseRepository
    {
        protected IMongoDatabase Database;

        public MongoDbBaseRepository([FromServices]MongoConnection mongoConnection)
        {
            try
            {
                var connectionString = mongoConnection.ConnectionString;
                var dbName = mongoConnection.Database;
                var conString = string.Format(connectionString, mongoConnection.User, mongoConnection.Password);

                var mongoClient = new MongoClient(conString);
                var mongoDatabaseSettings = new MongoDatabaseSettings();
                Database = mongoClient.GetDatabase(dbName, mongoDatabaseSettings);

                RegisterConventions();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new MongoConnectionException(null, "Não foi possível se conectar com o servidor.");
            }
        }

        public static void RegisterConventions()
        {
            ConventionRegistry.Register("CamelCase", new ConventionPack { new CamelCaseElementNameConvention() }, type => true);
            ConventionRegistry.Register("IgnoreExtraElements", new ConventionPack { new IgnoreExtraElementsConvention(true) }, type => true);
            ConventionRegistry.Register("DictionaryRepresentationConvention", new ConventionPack { new DictionaryRepresentationConvention(DictionaryRepresentation.ArrayOfArrays) }, type => true);
        }
    }

    public class DictionaryRepresentationConvention : ConventionBase, IMemberMapConvention
    {
        private readonly DictionaryRepresentation _dictionaryRepresentation;

        public DictionaryRepresentationConvention(DictionaryRepresentation dictionaryRepresentation)
        {
            _dictionaryRepresentation = dictionaryRepresentation;
        }

        public void Apply(BsonMemberMap memberMap)
        {
            if (memberMap.ClassMap.ClassType.Name == memberMap.MemberType.Name)
            {
                return;
            }
            Debug.WriteLine(memberMap.ClassMap.ClassType.Name + "." + memberMap.MemberName);
            memberMap.SetSerializer(ConfigureSerializer(memberMap.GetSerializer()));
        }

        private IBsonSerializer ConfigureSerializer(IBsonSerializer serializer)
        {
            if (serializer is IDictionaryRepresentationConfigurable dictionaryRepresentationConfigurable)
            {
                serializer = dictionaryRepresentationConfigurable.WithDictionaryRepresentation(_dictionaryRepresentation);
            }

            return !(serializer is IChildSerializerConfigurable childSerializerConfigurable)
                ? serializer
                : childSerializerConfigurable.WithChildSerializer(ConfigureSerializer(childSerializerConfigurable.ChildSerializer));
        }
    }
}
