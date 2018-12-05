function getEquipments() {
    $('#idTBodyIncorrect').empty();

    $.ajax({
        url: 'https://localhost:44393/Valider/GetEquipmentsByPost',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (data) {
            $.each(data, function (index, val) {
                alert("SN:  " + val.sn);
                if(val.sn === null){
                    val.sn = "";
                    //appendEquipment(val);
                }
                appendEquipment(val);
               
            });

        }

    });

}

function appendEquipment(equipment) {
    // if (equipment.sn === null)
    {
        var ligne = "<tr>";
        ligne += '<td>' +
            '<span class="input-group-addon">' +
            '<input type="checkbox" aria-label="...">' +
            '</span>' +
            '</td>';
        ligne += '<td>' + equipment.type + '</td>';
        ligne += '<td>' + equipment.modelName + '</td>';
        ligne += '<td>' + equipment.vendorName + '</td>';
        ligne += '<td>' + equipment.sn + '</td>';
        ligne += '<td> </td>';
        ligne += "</tr>";
        $('#idTBodyIncorrect').append(ligne);
    }

}