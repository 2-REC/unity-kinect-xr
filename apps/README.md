# APPS

## PROJECTS

### MAIN

The main application, the server...<br>
...<br>

### CLIENT

The client application, ...<br>
...<br>


## SETUP

The whole project can be used as-is, or integrated to another project (partly or completely).<br>

### PROJECT AS-IS

- Clone the repository<br>

- If required, manually clone/update the submodules<br>
    git submodule update --init --recursive

- Run "set_links.bat" script as Administrator<br>
    => It will create the symbolic links between the projects and the submodule.<br>
    - The script has to be run from a CMD window (seems like it doesn't work if right-click->"Run As Administrator")<br>
    - If can't have admin rights, copy the directories manually instead of using symbolic links.<br>
        The directories to copy are:<br>
        - SpaceBrew<br>
        - StreamingAssets<br>
        from "apps\Libraries\network\Assets" to "Assets".<br>

- "Main" project<br>
    - Open the project in Unity<br>
    - Import the "Kinect for Unity" package<br>
        => Look at the section "LIBRARIES - KINECT"<br>
    - Open "main" scene<br>

- "Client" project<br>
    - Open the project in Unity<br>
    - Open "main" scene<br>


### INTEGRATE TO ANOTHER PROJECT

#### "Main" Project

- Clone/Download the repository and its submodules<br>

- Open an existing Unity project or create a new project<br>

- In Windows Explorer, copy assets from the downloaded repository<br>
    - From "apps\Main\Assets":<br>
        - Kinect: If importing the Kinect package manually, no need to copy "Plugins" and "Standard Assets" directories.<br>
        - Scenes: Might not be necessary, depending on use.<br>
        - Scripts: Use, adapt or ignore...<br>
    - From "apps\Libraries\network\Assets"<br>
        - SpaceBrew<br>
        - StreamingAssets<br>

- In Unity, import the "Kinect for Unity" package<br>
    => Look at the section "LIBRARIES - KINECT"


#### "Client" Project

- Clone/Download the repository and its submodules<br>

- Open an existing Unity project or create a new project<br>

- In Windows Explorer, copy assets from the downloaded repository<br>
    - From "apps\Client\Assets":<br>
        - Scenes: Might not be necessary, depending on use.<br>
        - Scripts: Use, adapt or ignore...<br>
    - From "apps\Libraries\network\Assets"<br>
        - SpaceBrew<br>
        - StreamingAssets<br>


## LIBRARIES

Modules or packages used by the different applications.<br>


### SPACEBREW

...<br>
(from repo...)<br>


### KINECT

The provided "Kinect for Unity" package should be imported in the project in order to use the Kinect.<br>

If preferred, and if want to use the latest version of the package, it can be downloaded from the Microsoft website.<br>
However, it doesn't seem to change anymore, so the provided package should be enough.<br>


- (OPTIONAL) Download the "Kinect for Unity" package<br>
    From:<br>
    https://developer.microsoft.com/en-us/windows/kinect<br>
    ! - It is mentionned that it is a package for Unity Pro, but it works fine with the free Unity version.<br>

- Import the "Kinect for Unity" package<br>
    - "Assets" -> "Import Package" -> "Custom Package..."<br>
    - Navigate to "apps\Libraries" or to the download location if the package was downloaded separately (previous step).<br>
    - Select the package:<br>
        "Kinect.2.0.1410.19000.unitypackage" (or different version if downloaded separately)<br>
    - Import the full package:<br>
        => Both "Plugins" and "Standard Assets"<br>

- Move the imported assets to the "Kinect" folder<br>
    - from "Plugins"<br>
    - from "Standard Assets"<br>
    ! - MAKE SURE TO ONLY MOVE THE ASSETS RELATED TO KINECT! (the ones imported previously)<br>

The last step is not required, but helps kkeping a cleaner assets folder.<br>
(Also it is required to be like this in order for the ".gitignore" to work properly when using Git)<br>


### CAMERA VIEWER

Allows to visualise a device camera feed (front or rear) as background of a Unity camera or GameObject, useful for AR like camera view.<br>
...<br>
