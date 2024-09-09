E-Commerce Microservices Application

This project is a simple e-commerce application built using ASP.NET Core microservices architecture, designed to demonstrate scalability, flexibility, and modularity. It consists of three core microservices:

UserService: Manages user registration, authentication, and user-related operations.
OrderService: Handles order creation, order management, and processes related to user orders.
InventoryService: Manages inventory data, tracking product stock levels and updating quantities when orders are placed.
Each service operates independently with its own in-memory database and communicates with others via an event-driven architecture using MassTransit. For instance, when an order is placed, the OrderService emits an OrderCreated event, which is consumed by the InventoryService to update stock levels accordingly.

To simplify external access, the project uses an API Gateway powered by Ocelot. The API Gateway serves as a single entry point for client applications, routing requests to the appropriate microservices and handling cross-cutting concerns such as authentication, logging, and rate limiting. This decouples the clients from the underlying service structure and enhances maintainability and scalability.

Additional project features include:

Seeding Data: Each microservice seeds initial data (users, orders, and inventory items) upon startup.
Event-Based Communication: Services are loosely coupled, communicating via messages to ensure scalability and maintainability.
In-Memory Databases: Used for demonstration purposes, allowing for quick setup and testing without external dependencies.
This project offers a robust foundation for building microservices-based applications with clean separation of concerns and scalable architecture.
