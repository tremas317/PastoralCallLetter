# Pastoral Compensation Tool with Pastoral Call Letter

## About This Repository

This is the Visual Studio solution for the new Pastoral Compensation Tool with the pastoral call letter functionality.  

The solution and project are named PCLService and use the [DevExpress Office File API](https://docs.devexpress.com/OfficeFileAPI/) to perform a mailmerge on a Word template (the call letter), exporting the merged letter to either a Word or PDF document.

In order to maintain the tool, you will also need the [pastoral-compensation-tool repository](https://github.com/tremas317/pastoral-compensation-tool) which is a fork of the original tool located [here](https://github.com/darthpale/pastoral-compensation-tool).
This application was developed entirely in JavaScript and HTML using Vue and Node.js.  

## Instructions

The PCLService project has a folder named **pastoral-compensation-tool** which contains the runtime version of the Vue application.  See the readme.md file in the pastoral-compensation-tool repository for 
instructions on how to compile the runtime (production) application.  After running `yarn run build` you will need to copy a number of files into the **pastoral-compensation-tool** folder in the PCLService project:

* **css** folder:  Remove existing files in this folder, then copy files from .\dist\css.

* **js** folder:  Remove existing files in this folder, then copy files from .\dist\js.

* **fonts** folder:  Files in this folder come from .\dist\fonts and should not need to be updated unless fonts are changed.

* **img** folder:  Files in this folder come from .\dist\img and should not need to be updated.

Be sure to set the build action for each file to "Copy Always" in Visual Studio.

Also, note that the file **PastoralCallLetter.docx** is the Word merge template for the call letter.  Since this file is included in the project, you will need to be sure this file reflects the currently deployed template.

The PCLService project can then be published to Azure.  The current publish configuration deploys the runtime to [https://pclservice.azurewebsites.net](https://pclservice.azurewebsites.net).  

## Additional Information

Once the PCLService project is deployed, the home page of the site provides a way to upload a new call letter template.  The tool itself is located at ./pastoral-compensation-tool/index.html.
