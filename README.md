# Feedback Management System (ASP.NET MVC)

## Overview
The **Feedback Management System** is a web-based ASP.NET MVC application designed to streamline the process of collecting and analyzing student feedback for teachers. The system enables students to submit their ratings and comments, while teachers can view organized, data-driven reports that help improve teaching quality and academic performance.

---

## Features

### ✔ Student Feedback Submission  
Students can rate teachers and provide comments through a simple and intuitive form.

### ✔ Teacher Dashboard  
Teachers can view feedback reports, including ratings and comments submitted by students.

### ✔ Dynamic Report Table  
Feedback is displayed in a clean table format showing student names, ratings, and remarks.

### ✔ Secure & Reliable Architecture  
Built using ASP.NET MVC, ensuring robust data flow, model binding, and clean separation of concerns.

### ✔ Responsive UI  
Works smoothly across devices for easy access by both students and teachers.

---

## Tech Stack
- **Frontend:** HTML, CSS, Bootstrap  
- **Backend:** ASP.NET MVC (C#)  
- **Database:** SQL Server  
- **IDE:** Visual Studio  

---

## Folder Structure
/Controllers
- FeedbackController.cs
- TeacherController.cs

/Models
- Feedback.cs
- Teacher.cs

/Views
/Feedback
- Index.cshtml
- Create.cshtml
/Teacher
- Report.cshtml

yaml
Copy code
---

## How It Works
1. Students fill out the feedback form with rating and comments.  
2. The data is stored in the SQL Server database.  
3. Teachers view compiled reports displaying all student feedback in a structured table.  
4. The system ensures clear visibility and removes manual workload in evaluation.

---

## Sample Output (Teacher Report View)
| Student Name | Rating | Comment |
| Rahul | 4 | Very interactive session |
| Priya | 5 | Great explanation |
yaml
Copy code

---

## How to Run

1. Clone the repository  
2. Open the solution in **Visual Studio**  
3. Update the connection string in **appsettings.json / Web.config**  
4. Build and run the project  
5. Access the application in browser:  
https://localhost:<port>/

yaml
Copy code

---

## Future Enhancements
- Role-based authentication (Admin/Teacher/Student)  
- Chart-based analytics for visual representation of feedback  
- Export feedback to PDF/Excel  
- Email notifications for teachers  

---
## 🎥 Screen Recording Demo

Below is the screen-recorded demo of the **Feedback Management System (ASP.NET MVC)**:

👉 **Watch the Screen Recording:**  
[Click here to view the demo video]([YOUR_SCREEN_RECORDING_LINK_HERE](https://drive.google.com/file/d/1FsnAqxrz6dAlrEM4BRRbd7FN_HKkVUvP/view?usp=drive_link))

## License
This project is **open-source** and free to use for learning and academic purposes.
