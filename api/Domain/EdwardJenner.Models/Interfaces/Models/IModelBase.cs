using System;

namespace EdwardJenner.Models.Interfaces.Models
{
    public interface IModelBase
    {
        string Id { get; set; }
        DateTime UpdatedIn { get; set; }
    }
}
