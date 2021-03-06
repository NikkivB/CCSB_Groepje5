var today = new Date();

var todayDate = (today.getMonth() + 1) + '/' + (today.getDate() + 2) + '/' + today.getFullYear();

var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        dateInput: false,
        min: todayDate,
        //format: "d/M/yyyy hh:mm",
        //disableDates: function (date) {
        //    var disabled = [3, 7, 15, 8];
        //    if (date && disabled.indexOf(date.getDate()) > -1) {
        //        return true;
        //    } else {
        //        return false;
        //    }

        //}
    });
    InitializeCalendar();
});

var calendar;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            calendar = new FullCalendar.Calendar(calendarEl, {
                locale: 'nl',
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                weekNumbers: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);

                }
            });
            calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}

function onShowModal(obj, _isEventDeail) {
    $('#appointmentInput').modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
    if (!checkValidation()) return;
    var requestData = {
        CustomerId: $("#customerId").val(),
        VehicleId: $("#VehicleId").val(),
        StartDate: $("#appointmentDate").val(),
        EndDate: $("#appointmentDate").val(),
    };


    $.ajax({
        url: routeURL + "/api/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "success");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Foutje");
        }
    });
}

function checkValidation() {
    var isValid = true;
    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val().trim() === "") {
        isValid = false;
        $("#appointmentDate").addClass("error");
    } else {
        $("#appointmentDate").removeClass("error");
    }
    return isValid;
}