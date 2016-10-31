# p3_game
Group 303 semester project 2016

### Getting Started:

	1. Clone this git repository to whatever directory you want on your computer.
	2. Open the Unity project.
	3. Go to Edit -> Project Settings -> Editor
	4. Go to the right side of the screen, where the Inspector usually is
	5. Under "Version Control" make sure mode is set to "Visible Meta Files"
	6. Under "Asset Serialization" make sure the mode is set to "Force Text"

!!! If you do not follow these steps, Unity WILL NOT WORK with GitHub.

You must close Unity in order to add files to gitHub, otherwise it will not work.

	Keep in mind that the .gitIgnore file means that github will ignore all unity files except for those in PROJECT SETTINGS and in ASSETS. Any changes you make in these folders will affect the project in gitHub. Any other changes (such as customizing your unity UI layout) will NOT affect it, so you can do that freely.


### Working on the project in GitHub
	
	ALWAYS make a comment explaining what you have changed when you make a commit
	ALWAYS work in a new branch when working on a new feature, so you don't affect the whole project accidentally
	REMEMBER it is not just the code, any files you add, materials  or game object you create, will all be part of the commit 

### Notes on Organising The Project

	if the project is neatly organised in folders, everything will be easier for all of us. Put ALL scripts in the scripts folder, Materials in the Materials folder etc etc.

	When Coding, try keep all Variable and class names clear and descriptive, so that others can read it easily. A long name may seem annoying, but it is a lot easier to figure out what " int rateOfFire" is than what "int rf" is. 