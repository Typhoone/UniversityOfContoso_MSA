document.addEventListener("DOMContentLoaded", function () {
    var controller = document.body.getAttribute("data-ng-controller");
    if (controller == "tasks") {
        loadTaskTable(controller);
    }
});

function loadTaskTable(controller) {

    var userID = 1;

    var TaskTable = document.getElementById("taskTable");

    enrollmentModule.getEnrollment(userID, function (rollList) {
        setupTaskTable(rollList);
    });

    function setupTaskTable(enrollments) {



        //traverses thorugh enrollemts to find a math, poor code but best i can do at this stage
        for (i = 0; i < enrollments.length; i++) {
            if (enrollments[i].studentID == userID) {
                displayTaskRow(enrollments[i]);
            }
        }

        //appends table with data
        function displayTaskRow(enrollment) {

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
                    subBtn.innerHTML = "Submit";

                    subBtn.setAttribute("enroll-id", enrollment.EnrollmentID);
                    subBtn.setAttribute("data-btntype", "submit");

                    subCol.appendChild(subBtn);
                    row.appendChild(subCol);

                    //edit
                    var edtCol = document.createElement('td');
                    var edtBtn = document.createElement('button');
                    edtBtn.className = "btn btn-default";
                    edtBtn.innerHTML = "Delete";

                    edtBtn.setAttribute("enroll-id", enrollment.EnrollmentID);
                    edtBtn.setAttribute("data-btntype", "delete");

                    edtCol.appendChild(edtBtn);
                    row.appendChild(edtCol);

                    TaskTable.appendChild(row);

                }
            });



            document.getElementById("TableCourse").classList.remove("hidden");
            document.getElementById("loadinmsg").style.display = "none";

        }

        TaskTable.addEventListener('click', function (e) {
            var target = e.target;

            // Bubble up to tbody - need to bubble the event up because the click occurs in 
            // the td cells but the data-id attribute is in the row (for going to more detail page)
            while (target.nodeName.toLowerCase() !== "tbody") {

                // For all these cases we use the data-id stored in either the cell or the row to keep context
                // between seperate pages

                // Edit
                if (target.getAttribute("data-btntype") === "submit") {
                    window.location.href = 'edit.html' + '?type=' + controller + '&id=' + target.getAttribute("enroll-id");
                    return;

                    // Delete
                } else if (target.getAttribute("data-btntype") === "delete") {
                    enrollmentModule.deleteEnroll(target.getAttribute("enroll-id"), function () {
                        window.location.reload(true);
                    })
                    return;
                }

                // Keep bubbling the event up through the DOM
                target = target.parentNode;
            }
        });


    }

}