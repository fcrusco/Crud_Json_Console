# CRUD - Json - Console App

# Arquitetura, Funcionalidades e Tecnologias

Este projeto foi desenvolvido como uma aplicação de **Console em C# (.NET 8)** com o objetivo de demonstrar de forma prática a manipulação de arquivos JSON utilizando conceitos de CRUD (Create, Read, Update, Delete).  

<img width="472" height="420" alt="image" src="https://github.com/user-attachments/assets/0e7446a5-b3fe-4f4d-bff9-c2e3cb39e329" />


## Arquitetura

O código foi organizado em pastas para manter uma separação clara de responsabilidades, seguindo boas práticas de desenvolvimento e o princípio da responsabilidade única (SRP).  

📂 CrudJsonConsole  
 ┣ 📂 Model  
 ┃ ┗ 📜 Pessoa.cs → Classe que representa a entidade Pessoa (Id, Nome e Sobrenome).  
 ┣ 📂 Utils  
 ┃ ┣ 📜 JsonStorage.cs → Responsável por salvar, carregar e manipular os dados armazenados no arquivo JSON.  
 ┃ ┗ 📜 Menu.cs → Controla o menu de opções e a interação do usuário no console.  
 ┗ 📜 Program.cs → Ponto de entrada da aplicação, inicializa o menu e orquestra a execução.  

## Funcionalidades

- Listar todas as pessoas cadastradas.  
- Incluir uma nova pessoa.  
- Editar os dados de uma pessoa existente.  
- Excluir uma pessoa pelo Id.  
- Buscar pessoas pelo nome.  
- Exibir o caminho do arquivo JSON utilizado.  

## Tecnologias Utilizadas

- **C# 12 / .NET 8** → Plataforma de desenvolvimento.  
- **System.Text.Json** → Serialização e desserialização de dados em JSON.  
- **Console Application** → Interface simples baseada em linha de comando.  

---
# CRUD - Json - Console App

# Architecture, Features, and Technologies

This project was developed as a **Console Application in C# (.NET 8)** with the goal of demonstrating JSON file manipulation through CRUD operations (Create, Read, Update, Delete).  

## Architecture

The code is organized into folders to maintain a clear separation of responsibilities, following best practices and the Single Responsibility Principle (SRP).  

📂 CrudJsonConsole  
 ┣ 📂 Model  
 ┃ ┗ 📜 Pessoa.cs → Class that represents the Person entity (Id, FirstName, LastName).  
 ┣ 📂 Utils  
 ┃ ┣ 📜 JsonStorage.cs → Handles saving, loading, and managing data stored in the JSON file.  
 ┃ ┗ 📜 Menu.cs → Controls the options menu and user interaction in the console.  
 ┗ 📜 Program.cs → Application entry point, initializes the menu, and orchestrates execution.  

## Features

- List all registered people.  
- Add a new person.  
- Edit an existing person’s data.  
- Delete a person by Id.  
- Search people by name.  
- Display the path of the JSON file in use.  

## Technologies Used

- **C# 12 / .NET 8** → Development platform.  
- **System.Text.Json** → JSON serialization and deserialization.  
- **Console Application** → Simple command-line interface.  

---
# CRUD - Json - Console App

# Arquitectura, Funcionalidades y Tecnologías

Este proyecto fue desarrollado como una **Aplicación de Consola en C# (.NET 8)** con el objetivo de demostrar la manipulación de archivos JSON utilizando operaciones CRUD (Create, Read, Update, Delete).  

## Arquitectura

El código está organizado en carpetas para mantener una clara separación de responsabilidades, siguiendo buenas prácticas y el principio de responsabilidad única (SRP).  

📂 CrudJsonConsole  
 ┣ 📂 Model  
 ┃ ┗ 📜 Pessoa.cs → Clase que representa la entidad Persona (Id, Nombre y Apellido).  
 ┣ 📂 Utils  
 ┃ ┣ 📜 JsonStorage.cs → Responsable de guardar, cargar y administrar los datos en el archivo JSON.  
 ┃ ┗ 📜 Menu.cs → Controla el menú de opciones y la interacción del usuario en la consola.  
 ┗ 📜 Program.cs → Punto de entrada de la aplicación, inicializa el menú y orquesta la ejecución.  

## Funcionalidades

- Listar todas las personas registradas.  
- Incluir una nueva persona.  
- Editar los datos de una persona existente.  
- Eliminar una persona por Id.  
- Buscar personas por nombre.  
- Mostrar la ruta del archivo JSON en uso.  

## Tecnologías Utilizadas

- **C# 12 / .NET 8** → Plataforma de desarrollo.  
- **System.Text.Json** → Serialización y deserialización de datos en JSON.  
- **Aplicación de Consola** → Interfaz simple basada en línea de comandos.  
