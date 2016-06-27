/**
 * Created by Felix A. Bueno on 12/11/2015.
 */

$(document)
    .ready(function () {
        $("#branch-dialog")
            .dialog({
                autoOpen: false,
                modal: true,
                maxWidth: 600,
                width: "auto",
                height: "auto",
                fluid: true,
                resizable: false,
                draggable: false,
                buttons: {
                    "Ingresar": {
                        text: "Ingresar",
                        click: function () {
                            var model = new LogInViewModel($("#NickName").val(), $("#Password").val());
                            model.Company = $("#companies").val();
                            model.Branch = $("#branches").val();

                            $.ajax({ method: "Post", url: "/Authentication/LogIn", data: JSON.stringify(model), contentType: "application/json" })
                                .fail(function () {
                                    alert("Error en el sistema, por favor comunicar al area de soporte.");
                                });

                        },
                        "class": "btn btn-primary"
                    },
                    "Cancelar": {
                        text: "Cancelar",
                        click: function () {
                            ClearSelectBoostrap("companies");
                            ClearSelectBoostrap("branches");
                            $(this).dialog("close");
                        },
                        "class": "btn btn-default"
                    }
                }
            });

        $("#companies")
            .on("change",
                function () {
                    ClearSelectBoostrap("branches");
                    var dialog = $("#branch-dialog")[0];
                    var companies = jQuery.data(dialog, "access");
                    jQuery.each(companies,
                        function (index, value) {
                            if (value.Id === $("#companies").val()) {
                                jQuery.each(value.Branches,
                                    function (branchIndex, branchValue) {
                                        InsertItemSelectBoostrap("branches", branchValue.Id, branchValue.Description);
                                    });
                            }
                        });
                });

    });