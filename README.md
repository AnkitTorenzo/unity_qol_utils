# Quality of Life Utilities
I heard [Joel Spolsky](https://www.joelonsoftware.com/) (co-founder of [stackoverflow.com](https://stackoverflow.com/)) saying something along the lines of "If there is a system that takes 5 manual steps to complete it's execution, I'll automate it. I am a g**d*mn programmer" and this stuck with me every since. I always think how I can automate a process. Specially when it is keep bugging me.

For this plugin my intention is to gather all the small plugins and libraries that I've developed over the time to a single place. Also to experiment with the editor tools, and concepts that I've learned along the way.

By any mean this is not a finished or complete tool or a plugin. This is just bits and pieces that makes my workflow easy and keeps me from pulling my hairs out. I am open to suggestions and also for PRs. But I would be very happy if you can incorporate this plugin in your workflow and let me know your feedback.

## Install
 - Open Windows>Package Manager.
 - Click on the ```+``` button at the top right.
 - Select ```app package from git URL...```, and pest following url ```http://github.com/AnkitTorenzo/unity_qol_utils.git```

# Documentation
## Editor
### Open Terminal
This came in picture because I did not wanted to go to the ```Project Window > [Look For Assets Folder] > Open that in explorer > Right click > Open the terminal```. So I made a ```MenuItem()``` for this.
This options will open a terminal window at the root directory of your project.

In the menubar you can find this option at _QOL/Open Terminal At Project_ or if you are me and like to have a shortcut you can use ```Ctrl+` ```. And it is the same regardless of what os you are using.

**Note: As of now this only works with [Windows Terminal App](https://apps.microsoft.com/detail/9N0DX20HK701?hl=en-US&gl=US)**

### Open Explorer at Root
Same thing as open terminal. I thought I already can open a terminal so why don't I find out how to open how to open the explorer with a command line argument, and here is the result.

You can find this at _QOL/Open Explorer at root_ or for shortcut use ```Ctrl + Shift + Alt + f``` I know this is a bit much but I did not find anything batter to remember in this case.

**Note: This only works on Windows**

## Runtime
### ActionEvent