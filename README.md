# Tool PDF

A tool that helps extract and separate content from PDF files based on predefined settings. It supports batch processing, allowing multiple files to be processed at once.

---

## 📚 Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

---

## Introduction

This project is a tool designed to extract and separate content from PDF files based on user-defined settings. It allows users to configure how content should be split, and supports batch processing — enabling multiple PDF files to be processed at the same time.

It is especially useful in workflows where large volumes of documents need to be separated into structured parts, such as reports, forms, or data sheets.

---

## Prerequisites

List any required software or tools:

- .NET 9

---

## Installation

[⬇️ Download the .exe file (v1.0.0)](https://github.com/tieuquyngok1995/ToolPDF/releases/download/v1.0.0/ToolPDF.exe) and run it directly — no installation is required.

⚠️ If Windows shows a security warning, right-click the file → select Properties → check Unblock, then click OK.
Make sure you have permission to access the folders you plan to process.

## Usage

### 🔘 Button Overview

| No. | Button Name       | Description                                                             |
| --- | ----------------- | ----------------------------------------------------------------------- |
| ①   | **Open Folder**   | Selects the folder containing PDF files.                                |
| ②   | **Load File PDF** | Loads and displays the list of PDF files from the selected folder.      |
| ③   | **Save Setting**  | Saves the key settings entered in the table.                            |
| ④   | **Execute**       | Starts the content extraction process based on the saved settings.      |
| ⑤   | **Copy**          | Copies the extracted result to the clipboard (tab-separated for Excel). |
| ⑥   | **Clear**         | Clears all results and resets the interface.                            |

---

### ① Open Folder

Click the **① Open Folder** button or the folder icon next to the input field to choose the folder containing your PDF files.

---

### ② Load File PDF

After selecting a folder, click the **② Load File PDF** button to display the list of PDF files.
✅ Please check the total number of files shown to ensure it matches your expectation.

---

### 🧾 Input Settings

Fill in the settings table with the following columns:

| Column Name    | Description                                                                                            |
| -------------- | ------------------------------------------------------------------------------------------------------ |
| **Search Key** | The keyword used to locate values within the PDF content (No space end).                               |
| **End Key**    | If the extracted value contains extra text, enter the excess portion here to be automatically removed. |
| **Type**       | Specify the expected data type: `Text` or `Number`.                                                    |

---

### ③ Save Setting

After entering settings in the table, click the **③ Save Setting** button to store them.

> ⚠️ **Important**: If you change any setting, make sure to save it again **before executing**.
> The application only uses settings that have been saved successfully.

---

### ④ Execute

With both the file list and saved settings ready, click the **④ Execute** button to begin the extraction process.
The tool will extract values based on the order of keys, and output them as a tab-separated string (`\t`).

---

### ⑤ Copy

Click the **⑤ Copy** button to copy the result to the clipboard.
📋 You can paste the copied result directly into **Excel**, and it will automatically be split into columns.

---

### ⑥ Clear

Click the **⑥ Clear** button to remove all displayed results and reset the interface to its initial state.

---

## License
Tool PDF is licensed under the MIT License.

This means you are free to use, modify, and distribute this software for any purpose, as long as the original license and copyright notice are included.