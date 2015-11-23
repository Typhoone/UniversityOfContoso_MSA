document.addEventListener("DOMContentLoaded", function () {
    $(".showBtn").click(function () {
        $(".oldTbl").toggle('show');
    });

    var controller = document.body.getAttribute("data-ng-controller");
    if (controller == "Tasks") {
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
        
        
        var tasks = [];
        courseModule.getTasks(function (taskList) {
            for (i = 0; i < taskList.length; i++) {
                tasks.push(taskList[i]);
            }

            addToTable(tasks, enrollments);
        });
        
        
       
    }

    function addToTable(tasks, enrollments) {

        var table = document.getElementById("assigContentTable");
        var oldTable = document.getElementById("OldassigContentTable");

        for(i = 0; i < enrollments.length; i++){
            for (j = 0; j < tasks.length; j++) {
                if (enrollments[i].CourseID == tasks[j].CourseID) {
                    var row = document.createElement('tr');
                    row.setAttribute("data-id", enrollments[i].CourseID);

                    var courseIDcol = document.createElement('td');
                    courseIDcol.innerHTML = enrollments[i].CourseID;
                    row.appendChild(courseIDcol);

                    var courseDuecol = document.createElement('td');
                    courseDuecol.innerHTML = tasks[j].DueTime;
                    row.appendChild(courseDuecol);

                    var courseLinkcol = document.createElement('td');
                    var a = document.createElement('a');
                    var linkText = document.createTextNode("Link");
                    a.appendChild(linkText);
                    a.title = "Link";
                    a.href = "http://" + tasks[j].AssigLink;
                    a.classList.add("btn");
                    a.classList.add("btn-info");

                    courseLinkcol.appendChild(a);
                    
                    row.appendChild(courseLinkcol);

                    var currenttimeStamp = Math.floor(Date.now());

                    var dueTimestamp = Date.parse(tasks[j].DueTime);

                    if (currenttimeStamp < dueTimestamp) {
                        table.appendChild(row);
                    } else {
                        oldTable.appendChild(row);
                    }
                    


                }

                document.getElementById("loadinmsg").style.display = "none";
                document.getElementById("oldloadinmsg").style.display = "none";
            }
        }

        /*table.addEventListener('click', function (e) {
            var target = e.target;
            alert();
            if (target.getAttribute("data-btntype") === "link") {
                
                window.open(target.getAttribute("link-id"), "_self")
                return;
            }
            
        });*/
        
    }

}