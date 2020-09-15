# 3DSimulationTest
# Problem definition
This Application can place a certain number of boxes (Get Amount from API) in world space in front of the camera and connect them with connectors.
# Completed Task
1. Git version control of the project and host on Github. (make it open source)
2. All the applicable actions are UI clickable.
3. Number of boxes (from api endpoint) to be spawned.
4. Spawn the boxes in the world space in front of camera. (color them randomly)
5. Boxes are draggable in Unity’s X-Z axis world space.
6. Create draggable connectors to connect the boxes.
7. Camera movement for roaming around the scene to observe them. (Details Follow the Documentation)
8. WebGL build of the project, upload on github.io. &
9. Document of instructions to operate the final submitted. Follow the link.
# API Endpoint Details
1. Endpoint https://us-central1-marine-set-274003.cloudfunctions.net/GetTotalBoxes
2. For a GET method add a query param with key “name” and value “IDARE” or “idare”
3. Receive number of boxes in json format like { “boxes”: 7 }
https://photos.app.goo.gl/bAmLKqvi74LEEyH6A
