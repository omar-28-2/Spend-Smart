# SpendSmart

SpendSmart is a personal expense tracking and budgeting desktop application built with C#. It helps users monitor their spending habits, manage budgets, and analyze expenses efficiently.

## 🚀 Features
- Add, update, and delete expense records
- Categorize expenses (e.g., Food, Transportation, etc.)
- View summaries and reports
- Simple and intuitive user interface

## 🛠 Technologies Used
- **C#** (.NET Framework)
- **Windows Forms (WinForms)** for UI
- **SQL Server** for data storage
- **Visual Studio** for development

## 📦 Project Structure
```
SpendSmart/
├── SpendSmart.sln            # Solution file
├── /bin                      # Build output (ignored)
├── /obj                      # Intermediate build files (ignored)
├── Insertdatasql.sql         # Database schema and initial data
├── README.md                 # Project documentation
├── .gitignore                # Files and folders to ignore in Git
```

## 🧰 Getting Started
### Prerequisites
- Visual Studio 2019/2022
- SQL Server (Express or full version)

### Setup Instructions
1. **Clone the Repository**
```bash
git clone <your-repo-url>
```
2. **Open `SpendSmart.sln` in Visual Studio**
3. **Set up the database**
   - Open `Insertdatasql.sql` in SQL Server Management Studio
   - Execute the script to create and populate the database
4. **Update connection string** (if needed) in `App.config` or wherever applicable.
5. **Build and run the solution**

## 🖼 Screenshots
> _You can add screenshots of your app UI here to demonstrate its functionality._

## 💾 Database Setup
- All necessary tables and sample data are included in the `Insertdatasql.sql` file
- **Note:** This file is listed in `.gitignore` for privacy. Add it back if needed when sharing schema.

## 📌 How to Run
- Open in Visual Studio
- Configure DB connection
- Build solution (`Ctrl + Shift + B`)
- Run (`F5`)

## 🤝 Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## 📄 License
This project is licensed under the [MIT License](LICENSE).

---

> Developed with ❤️ by Omar Elhossiny 

