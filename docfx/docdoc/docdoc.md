# How to build the documentation 

We use docfx to generate our documentation.  
First make sure you already have the folder "docfx" in the same folder of the project.  
We have already script that can generate it.  

Open a powershell terminal in administrator mode.  
Get on the docfx path with cd command.  

### Then install docfx with our script : 
.\installDocfx

If your system doesn't allow this, you can just copy paste the contenu of the script.

### Finally generate the documentation :
.\generateDocs

If your system doesn't allow this, you can just copy paste the contenu of the script.

### It is recommanded to clean the docs if you are developping it in between each generate.
.\cleanObj

If your system doesn't allow this, you can just copy paste the contenu of the script.

