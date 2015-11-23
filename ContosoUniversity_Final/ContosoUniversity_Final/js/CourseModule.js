var courseModule = (function () {

    return {
        getCoursefromID: function (id, callback) {
            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {
                //this is called after the xhhtp.send as at this stage the xhttp var has not been changed
                if (xhttp.readyState == 4 && xhttp.status == 200) {
                    loadedCourseInfo();
                }
            }

            //connects and queries for the data
            xhttp.open("GET", "http://contosouniversitygmadams.azurewebsites.net/api/Courses/" + id, true);
            xhttp.setRequestHeader("Content-type", "application/json");
            xhttp.send(null);


            //parse the JSON data and send it back to that who called it
            function loadedCourseInfo() {
                var courseList = JSON.parse(xhttp.responseText);
                callback(courseList);
                return courseList;
            }
        }
    };

}());