/**
 * Created by Felix A. Bueno on 12/17/2015.
 */
function InsertItemSelectBoostrap (id, value, text)
{
    $ ("#" + id).append ("<option value='" + value + "'>" + text + "</option>");
    $ ("#" + id).selectpicker ("refresh");
}

function ClearSelectBoostrap (id)
{
    $ ("#" + id).html ("");
    $ ("#" + id).selectpicker ("refresh");
}

function ActiveSelectBoostrap (id)
{
    $ ("#" + id).prop ("disabled", false);
    $ ("#" + id).selectpicker ("refresh");
}