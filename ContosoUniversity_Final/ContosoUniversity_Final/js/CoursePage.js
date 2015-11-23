document.addEventListener("DOMContentLoaded", function () {
    var controller = document.body.getAttribute("data-ng-controller");
    if (controller == "courses") {
        loadCoursesTable(controller);
    }
});

function loadCoursesTable(controller) {

    var userID = 1;

    var courseTable = document.getElementById("courseContentTable");

    enrollmentModule.getEnrollment(userID, function (rollList) {
        setupCourseTable(rollList);
    });

    function setupCourseTable(enrollments) {

        

        //traverses thorugh enrollemts to find a math, poor code but best i can do at this stage
        for (i = 0; i < enrollments.length; i++) {
            if (enrollments[i].studentID == userID) {
                displayCourseRow(enrollments[i]);
            }
        }

        //appends table with data
        function displayCourseRow(enrollment) {

            courseModule.getCoursefromID(enrollment.CourseID, function (courseList) {
                for (i = 0; i < 1; i++) {

                    var row = document.createElement('tr');
                    row.setAttribute("data-id", enrollment.EnrollmentID);

                    //create cols
                    var courseIDcol = document.createElement('td');
                    courseIDcol.innerHTML = courseList.courseID;
                    row.appendChild(courseIDcol);

                    var courseNamecol = document.createElement('td');
                    courseNamecol.innerHTML = courseList.CourseName;
                    row.appendChild(courseNamecol);

                    var courseLoc = document.createElement('td');
                    courseLoc.innerHTML = courseList.Location;
                    row.appendChild(courseLoc);

                    var courseTim = document.createElement('td');
                    courseTim.innerHTML = courseList.Time;
                    row.appendChild(courseTim);

                    var courseDay = document.createElement('td');
                    courseDay.innerHTML = courseList.Days;
                    row.appendChild(courseDay);

                    var courseTpe = document.createElement('td');
                    courseTpe.innerHTML = courseList.Type;
                    row.appendChild(courseTpe);


                    //submit button
                    var subCol = document.createElement('td');
                    var subBtn = document.createElement('button');
                    subBtn.className = "btn btn-default";
                    subBtn.innerHTML = "Edit";

                    subBtn.setAttribute("data-id", enrollment.EnrollmentID);
                    subBtn.setAttribute("data-btntype", "submit");

                    subCol.appendChild(subBtn);
                    row.appendChild(subBtn);

                    courseTable.appendChild(row);

                }
            });

            

            document.getElementById("TableCourse").classList.remove("hidden");
            document.getElementById("loadinmsg").style.display = "none";
            
        }


    }

}