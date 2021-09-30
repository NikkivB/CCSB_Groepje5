$(document).ready(function () {
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
function onShowModal(obj, isEventDeail) {
    $("#appointmentInput").modal("show");
}
function onCloseModal() {
    $("#appointmentInput").modal("hide");
}
function onSubmitForm() {
    var requestData = {
        Id: parseInt($("id").val()),
        Title: $("#title").val(),
        Description: $("#description").val(),
        StartDate: $("#appointmentDate").val(),
        Duration: $("#duration").val(),
        Duration: $("#klantId").val()
    };

    $.ajax({
        url: routeURL + "/api/AppointmentApi/SaveCalendarData",
        type: "POST",
        data: JSON.stringify(requestData),
        contentType: "application/json",
        succes: function (response) {
            if (response.status === 1 || response.status === 2) {
                $.notify(response.message, "succes");
                onCloseModal();
            } else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "Foutje");
        }
    });

    $(document).ready(function () {
        $("#appointmentDate").kendoDateTimePicker({
            value: new Date(),
            dateInput: false
        });
        InitializeCalendar();
    });

}
