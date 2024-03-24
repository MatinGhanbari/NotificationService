
![Logo](https://blog.postman.com/wp-content/uploads/2023/11/What-is-gRPC_.jpg)


# NotificationService

The NotificationService is a standalone microservice that handles notification management and delivery. It consumes events from a message bus and uses gRPC to send the notification to gRPC clients, which are likely notification-handling applications.


## Acknowledgements

 - [gRPC](https://grpc.io/docs/what-is-grpc/core-concepts)
 - [Event-Driven Architecture]()
 - [RabbitMQ](https://www.rabbitmq.com/)



## Deploy

To deploy service on docker run this line of code:

```bash
$ docker-compose up --build
```

## How to use

GRPC URL:
```grpc://localhost:8081```

Proto: [NotificationProto](notification.proto)
    
## License

[MIT](https://choosealicense.com/licenses/mit/)


## Authors

- [@MatinGhanbari](https://www.github.com/MatinGhanbari)


## Contributing

Contributions are always welcome!

See `contributing.md` for ways to get started.

Please adhere to this project's `code of conduct`.

