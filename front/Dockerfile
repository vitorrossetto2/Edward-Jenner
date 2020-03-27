FROM node:10.16.0-alpine as node
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:alpine
COPY --from=node /app/dist /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/nginx.conf