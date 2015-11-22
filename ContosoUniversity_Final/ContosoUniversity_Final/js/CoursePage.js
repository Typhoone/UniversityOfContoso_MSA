document.addEventListener("DOMContentLoaded", function () {
    var controller = document.body.getAttribute("data-controller");
    if (controller == "courses") {
        loadCoursesTable(controller);
    }
});

function loadCoursesTable(controller) {

    var courseTable = document.getElementById("courseContentTable");

    enrollmentModule.getEnrollment(function (rollList) {
        setupCourseTable(rollList);
    });

    function setupCourseTable(enrollments) {

        var userID = 1;

        //traverses thorugh enrollemts to find a math, poor code but best i can do at this stage
        for (i = 0; i < enrollments.length; i++) {
            if (enrollments[i].studentID == userID) {
                courseModule.getCoursefromID(enrollments[i].CourseID, function (courseList) {//making function in loop even worse code but i dont know a better way
                    displayCourse(courseList);
                });
            }
        }

        //appends table with data
        function displayCourse(courses){

        }


    }

}