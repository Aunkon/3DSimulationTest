# 3DSimulationTest
Play this Game and Playing Documentation from this link - https://github.com/Aunkon/3DSimulationWebGL

# Problem definition
This Application can place a certain number of boxes (Get Amount from API) in world space in front of the camera and connect them with connectors.
![](https://lh3.googleusercontent.com/pw/ACtC-3f3zDM43cV2-3H6KoM04HomI3AN1c65cZ4hZYW3a99TLAc78pRoiDrDjuDJ-gHoJFtB7BRU5FbLB4la3EsxEdsKfkoEVpnJ8F8wg5DHJahpEg8QIdeZ6W0j79TR9VUwUSQFMcxjElTYTTObL3BWHEiwHg=w1072-h839-no)

# API Endpoint Details
1. Endpoint https://us-central1-marine-set-274003.cloudfunctions.net/GetTotalBoxes
2. For a GET method add a query param with key “name” and value “IDARE” or “idare”
3. Receive number of boxes in json format like { “boxes”: 7 }

# Research and Development.
1. This is the first time I use GitHub. Basically I use Tortoise svn for version control.
2. Find Boxes Dragging and re-scaling using drag on online. But finally, figure it out by myself.
3. Other small parts of this project's I was experienced with my professional life.

# Integration.
1. First I create a GitHub Repository.
2. Then start to collect every resource I find online for this project.
3. Try to Design a solution to solve this in my mind.
![](https://lh3.googleusercontent.com/pw/ACtC-3cOZyKMAQxj2TJOeW78KcEK-bhW4m25vW-gVJ92Bcf1QB8_6rL0ziNlynATbEDwqK0yffgcLfpNnVg6nZX_CDoAdJYoY7EzydMuVsbk9h3D-5uqbiTIf1OaLLxkMqMlK3UxTnxSgDkHTJ0HnSghmOpGpw=w1263-h947-no?authuser=0)
4. Follow this step to complete the project.

# Resources
1. Camera Navigation - https://gist.github.com/McFunkypants/5a9dad582461cb8d9de3
2. API Data processing, Spawn Object with Circular position around the Root - Mathematics.
3. Dragging Object - https://answers.unity.com/questions/1141458/drag-and-drop-along-x-and-z-axis.html
4. Connect with Edge and Resize Edge - my Vector 3 knowledge from physics and Mathematics

# Completed Task
1. Git version control of the project and host on Github. (make it open source)
2. All the applicable actions are UI clickable.
3. Number of boxes (from api endpoint) to be spawned.
4. Spawn the boxes in the world space in front of camera. (color them randomly)
5. Boxes are draggable in Unity’s X-Z axis world space.
6. Create draggable connectors to connect the boxes.
7. Camera movement for roaming around the scene to observe them. (Details Follow the Documentation)
8. WebGL build of the project, upload on github.io. &
9. Document of instructions to operate the final submitted. Follow the link - https://aunkon.github.io/3DSimulationWebGL/index.html
