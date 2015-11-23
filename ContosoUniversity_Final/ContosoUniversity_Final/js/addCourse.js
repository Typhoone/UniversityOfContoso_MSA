document.addEventListener("DOMContentLoaded", function () {
    var controller = document.body.getAttribute("data-ng-controller");
    if (controller == "addCourse") {
        loadCourses(controller);
    }
});

function loadCourses(controller) {
    var userID = 1;

    var courseOptions = document.getElementById("courseOptions");

    courseModule.getCourses(function (courseList) {
        setupCourseList(courseList);
    });

    function setupCourseList(courseList) {

        for (i = 0; i < courseList.length; i++) {
            var option = document.createElement('option');
            option.innerHTML = courseList[i].CourseName;
            option.setAttribute("value", courseList[i].courseID);
            courseOptions.appendChild(option);

        }

        var button = document.getElementById("enrolBtn");

        button.classList.remove("disabled");

        button.addEventListener('click', function (e) {
            var target = e.target;
            if (target.getAttribute("id") == "enrolBtn") {
                var courseNum = $("#courseOptions option:selected");//gets the selected option

                var newEnrollment = {
                    CourseID: courseNum.val(),
                    studentID: userID,
                    gradePercent: 0
                };

                enrollmentModule.addEnrollment(newEnrollment, function () {
                    window.location.href = "Courses.html";
                })
            }
        })
    }


}