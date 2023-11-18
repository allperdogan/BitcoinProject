# Bitcoin Value Tracker

This is a full-stack application that tracks and displays the historical values of Bitcoin. It includes a .NET Core backend with PostgreSQL for data storage, an Angular frontend for visualization, and a background service for periodic data updates.

## Features

- **Backend:** .NET Core, Entity Framework, PostgreSQL
- **Frontend:** Angular, Ngx-Charts
- **Background Service:** .NET Core Worker
- **Dockerized:** Uses Docker Compose for easy deployment
- **Authentication:** .NET Identity for user authentication

## Usage

1. Clone the repository.
2. Run `docker-compose up` to start the application.
3. Access the frontend at `http://localhost:4200`.
4. Log in to view the Bitcoin value graph.
5. Choose the time interval (day, week, month) and click "Update Graph" to refresh the data.

## Requirements

- Docker
- Node.js
- .NET Core SDK

## Contributing

Feel free to open issues, submit pull requests, or suggest improvements. Contributions are welcome!

## License

This project is licensed under the [MIT License](LICENSE).
