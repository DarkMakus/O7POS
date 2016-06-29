/**
 * Created by Felix A. Bueno on 12/11/2015.
 */
function UserAccess ( )
{
    var model = new LogInViewModel ($ ("#NickName").val ( ), $ ("#Password").val ( ));
    $.ajax ({ method: "Post", url: "/Authentication/GetAccess", data: JSON.stringify (model), contentType: "application/json" })
        .done (function (result)
        {
            jQuery.each (result, function (index, value) { InsertItemSelectBoostrap ("companies", value.Id, value.Description) });
            var branchDialog = $ ("#branch-dialog");
            branchDialog.dialog ("open");
            jQuery.data (branchDialog[0], "access", result);
        })
        .fail (function ( )
        {
            alert ("Error en el sistema, por favor comunicar al area de soporte.");
        });
}