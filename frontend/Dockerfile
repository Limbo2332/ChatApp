FROM node as builder
COPY . /app
WORKDIR /app
RUN npm install
RUN npm run lint
RUN npm run build

FROM nginx:1.17.10-alpine
COPY --from=builder /app/dist/frontend /usr/share/nginx/html
COPY /nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
