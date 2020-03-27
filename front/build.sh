#!/bin/bash

APPNAME="edwardjenner"
APPTYPE="front"
SERVER="registry.lennon.cloud"
TIMESTAMP=$(date "+%Y.%m.%d-%H.%M")

echo "Construindo a imagem ${SERVER}/${APPNAME}/${APPTYPE}:${TIMESTAMP}"
docker build -t ${SERVER}/${APPNAME}/${APPTYPE}:${TIMESTAMP} .

echo "Marcando a tag latest também"
docker tag ${SERVER}/${APPNAME}/${APPTYPE}:${TIMESTAMP} ${SERVER}/${APPNAME}/${APPTYPE}:latest

echo "Enviando a imagem para nuvem docker"
docker push ${SERVER}/${APPNAME}/${APPTYPE}:${TIMESTAMP}
docker push ${SERVER}/${APPNAME}/${APPTYPE}:latest

export TIMESTAMP