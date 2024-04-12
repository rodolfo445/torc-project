<a name="readme-top"></a>

<details>
  <summary>Table of Contents</summary>
  <ul>
    <li><a href="#project-architecture">Project Architecture</a>
      <ul>
        <li><a href="#modular-and-flexible-structure">Modular and Flexible Structure</a></li>
        <li><a href="#benefits">Benefits</a></li>
      </ul>
    </li>
    <li><a href="#project-structure">Project Structure</a>
      <ul>
        <li><a href="#core">Core</a></li>
        <li><a href="#infrastructure">Infrastructure</a></li>
        <li><a href="#eventHandlers">EventHandlers</a></li>
      </ul>
    </li>
    <li><a href="#getting-started">Getting Started</a>
        <ul>
          <li><a href="#prerequisites">Prerequisites</a></li>
          <li><a href="#backend">Backend</a></li>
          <li><a href="#frontend">Frontend</a></li>
        </ul>
    </li>
  </ul>
</details>

# Royal Library

<p align="right">(<a href="#readme-top">back to top</a>)</p>

`RoyalLibrary` is a system developed using .NET 7 and C# to serve as an API for a bookstore. It leverages the principles of Clean Architecture to provide a robust and scalable solution of microservice. The project is organized into different modules, including Application, Controllers and Infrastructure. To keep the example simpler and more straightforward, they were not divided into Projects but rather into folders.

## Project Architecture

<p align="right">(<a href="#readme-top">back to top</a>)</p>

The RoyalLibrary is built following the principles of **Clean Architecture**. This architectural approach centers the system's business logic, keeping it decoupled from infrastructure details and user interfaces. This promotes greater flexibility, testability, and maintainability of the code.

### Modular and Flexible Structure

By adopting Clean Architecture, `RoyalLibrary` organizes its code into clearly defined modules corresponding to different areas of responsibility:

- **Application**: Contains the essential business logic and domain models. This is the part of the application that encapsulates fundamental rules and operations, such as managing and listing books.

- **Controllers**: They help maintain separation of concerns by handling the web-specific concerns, while leaving the business logic to other components such as services or models.

- **Infrastructure**: Provides the necessary infrastructure for the application to run, including database configurations, such as migrations and entity mappings, and other infrastructure-related concerns.

### Benefits

Clean Architecture offers multiple benefits for the development and maintenance, for example:

- **Testability**: The clear separation between business logic and external interfaces facilitates the creation of automated tests, allowing the business logic to be tested in isolation.

- **Flexibility**: Makes it easier to replace or add new adapters to connect to different services or technologies without changing the core application logic.

- **Maintainability**: The modularity and clarity of the project structure simplify understanding the code and implementing changes or improvements.

In summary, the architecture aims to create a robust and adaptable system, capable of evolving and integrating easily into a constantly changing technological ecosystem while keeping its business logic protected and clearly defined.

## Project Structure

<p align="right">(<a href="#readme-top">back to top</a>)</p>

The system adopts a modular architecture inspired by the principles of Hexagonal Architecture. This approach emphasizes the clear separation between the system's business logic and the interaction interfaces with the external world. Below is a detailed view of each main project component.

### Core

#### Models
- **Book**: Represents the central entity in the system, containing information such as Title, Authors, ISBN.

#### Application
- **UseCases**: Encapsulate business logic for operations of the books, managing them. Each use case is implemented to be independent of input and output means, allowing reuse in different contexts. For example, the `SearchBooksUseCase` use case can be triggered by an HTTP request or a message from a queue, without changing the core logic.


### Infrastructure

#### Database
- **BooksDbContext**: Infrastructure related to SQL in memory database operations, including entity configurations and migrations. This component is crucial for data persistence and retrieval, supporting the application's data storage needs. For this example was used an in memory database but this is easily changed in the configuration.

### EventHandlers
- **InMemoryEventBus**: The InMemoryEventBus provides a lightweight, in-memory event bus implementation for handling events within your application. It allows for decoupling between event publishers and subscribers, enabling flexible and efficient communication between different parts of the system.
  
  -  **Features**:
    1. Event Subscription: Subscribe event handlers to specific event types.
    2. Event Publishing: Publish events to the event bus for processing by subscribed handlers.
    3. Loosely Coupled Communication: Facilitates communication and coordination between different components of the application through loosely coupled events.
 
## Getting Started

<p align="right">(<a href="#readme-top">back to top</a>)</p>

This section provides guidance on how to run the `Royal Library` system locally, including requirements and step-by-step instructions for both .NET 7 and Docker Compose environments.

### Prerequisites

- **.NET 7 SDK**: Required to build and run the .NET projects locally. You can download the .NET 8 SDK from the official .NET website: [Download .NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).

### Backend

1. **Clone the Repository**: Start by cloning the `torc-project` repository to your local machine using the following command:

   ```bash
   git clone https://github.com/rodolfo445/torc-project.git
    ```
2. **Navigate to the Project Directory**: Move into the `Royal Library` directory using the following command:

   ```bash
   cd torc-project/backend
   ```
3. **Run the project**: Use the `dotnet run` command to run the backend application.
    
   ```bash
   dotnet run
   ```
   
4. **Access the Application**: Once the application is running, you can access the exposed HTTP endpoints using a tool like `curl` or OpenAPI clients like Swagger or Postman. Here's follow the swagger endpoint:

   ```bash
      http://localhost:5021/swagger/index.html
    ```


5. **Run the front-end**: Once the application is running, you can access the frontend page called `index.html` to make the requests to the backend:


### Frontend
The frontend was built using Vanilla Javascript. I opted for vanilla JavaScript instead of React for its simplicity.

1. Simplicity: Vanilla JavaScript requires no additional setup or dependencies. With React, setting up the development environment involves installing Node.js, configuring webpack or Create React App, and managing dependencies. This adds complexity, especially for small projects.

2. Lightweight: Vanilla JavaScript is lightweight compared to React. React comes with its own Virtual DOM and reconciliation algorithm, which may be overkill for simple applications. Using vanilla JavaScript means fewer resources are required, resulting in faster load times and better performance.

3. Flexibility: Vanilla JavaScript offers more flexibility in choosing libraries and frameworks for specific tasks. While React is powerful for building UI components, it may not be the best choice for every project. Vanilla JavaScript allows developers to tailor solutions to their exact requirements without being tied to a specific framework.

4. Scalability: For small projects, the overhead of React may outweigh its benefits. Vanilla JavaScript provides a simpler and more scalable solution that can easily be extended as the project grows.


About styling, I used vanilla CSS over a CSS framework for its simplicity and flexibility. Opting for vanilla CSS meant avoiding additional setup or dependencies, allowing for a streamlined development process and providing greater control over styling. 

By choosing vanilla CSS, I prioritized simplicity, customization, and performance, ultimately facilitating a smoother and more efficient development workflow due to time constraints.
