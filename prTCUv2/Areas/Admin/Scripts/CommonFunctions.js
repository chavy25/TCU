$(document).ready(function () {
    $(function () {
        var connection = $.hubConnection();
        var SingleSessionHubProxy = connection.createHubProxy('SingleSessionHub');

        SingleSessionHubProxy.on('UserClientsOnline', function (result) {
            if (result <= 0) {
                $.ajax({
                    url: "/Home/Logout/",
                    data: { Module: "webAdmin" },
                    cache: false,
                    type: "POST"
                });
            }
        });

        SingleSessionHubProxy.on('AlertMessage', function (result) {
            $("#UserInfo").html("<div class='alert slim alert-info'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Info!</strong> " + result + " </div>");
        });

        connection.start();

        $("#UserLogOut").on("click", function () {
            connection.start().done(function () {
                SingleSessionHubProxy.invoke('DeleteConnectionIDs').done(function () {
                    $.ajax({
                        url: "/Home/Logout/",
                        data: { Module: "webAdmin" },
                        cache: false,
                        type: "POST"
                    }).done(function () {
                        document.location.href = "/";
                    });
                }).fail(function (error) {
                    document.location.href = "/";
                });
            });
        });

        $("#Alert").on("click", ".close", function () {
            $('.alert-slim').alert("close");
        });

    });
});

function ErrorAlert(Description) {
    $("#Alert").html("<div class='alert slim alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> " + Description + " </div>");
    $("#Alert > div").delay(10000).toggle("fade");
    $("html, body").animate({ scrollTop: $("body").offset().top }, "slow");
}

function SuccessAlert(Description) {
    $("#Alert").html("<div class='alert slim alert-success'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Success!</strong> " + Description + " </div>");
    $("#Alert > div").delay(10000).toggle("fade");
}

function InfoAlert(Description) {
    $("#Alert").html("<div class='alert slim alert-info'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Info!</strong> " + Description + " </div>");
    $("#Alert > div").delay(10000).toggle("fade");
}

function WarningAlert(Description) {
    $("#Alert").html("<div class='alert slim alert-warning'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Warning!</strong> " + Description + " </div>");
    $("#Alert > div").delay(10000).toggle("fade");
    $("html, body").animate({ scrollTop: $("body").offset().top }, "slow");
}

function ChangeTab() {
    if (Lockr.get('user_id')) {
        $(".TabAction").each(function () {
            $(this).attr("href", "/Admin/" + this.name + "/Management/" + Lockr.get('user_id'));
        });
    }
}

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};