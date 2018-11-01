function checkTimeout(data) {
    var thereIsStillTime = true;

    if (data) {
        
        var ParsedValue = tryParseJSON(data);

        if (typeof ParsedValue === "object") {

            if (ParsedValue.responseText == "False")
                thereIsStillTime = false;
            else if (ParsedValue.Error) {
                $("#Alert").html("<div class='alert slim alert-danger'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> " + ParsedValue.Error + " </div>");
                $("html, body").animate({ scrollTop: $("body").offset().top }, "slow");
                return false;
            }
        }
        else {
            if ((data.indexOf("<title>PSB - Main Login</title>") > -1)) thereIsStillTime = false;
        }

        if (!thereIsStillTime) {
            window.location.href = "/";
        }
    } else {
        $.ajax({
            url: "/Home/checkTimeout/",
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            complete: function (result) {
                thereIsStillTime = checkTimeout(result);
            }
        });
    }

    return thereIsStillTime;
}

function tryParseJSON(jsonString) {
    try {
        if (typeof jsonString === "object")
            return jsonString;

        var o = JSON.parse(jsonString);

        if (o && typeof o === "object" && o !== null) {
            return o;
        }
    }
    catch (e) { }

    return false;
};