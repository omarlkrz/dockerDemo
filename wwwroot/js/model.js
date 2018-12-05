


function getTypesDevices() {

    $(document).ready(function () {

        $.ajax({
            type: 'GET',
            url: 'https://localhost:44393/TypeDevice/GetAllTypeDevices',
            dataType: 'json',
            success: function (data) {

                $.each(data, function (index, val) {

                    var ligne = "<option value= \"" + val.idTypeDev + "\">" + val.description + "</option>";

                    $("#idTypeDevice").append(ligne);
                    $("#idTypeDevUpdate").append(ligne);

                });
            }
        });
    }
    );
}

function getVendors() {

    $(document).ready(function () {

        $.ajax({
            type: 'GET',
            url: 'https://localhost:44393/Vendor/GetAllVendors',
            dataType: 'json',
            success: function (data) {


                $.each(data, function (index, val) {

                    var ligne = "<option value= \"" + val.idVendor + "\">" + val.description + "</option>";

                    $('#idVendors').append(ligne);
                    $('#idVendorUpdate').append(ligne);

                });
            }
        });
    }
    );
}





function getModels() {

    $(document).ready(function () {

        $('#idRecherche').click(function () {
            ViewModels();
            sortTable();

        });
    }
    );
}


function loadModel(descriptionDev, nameVendor, descriptionModel, SNDetectable, modelDetectable, propriete, codeModel, numDev, codeVendor) {

    $('#idTypeDevUpdate').val(numDev);
    $('#idDescriptionUpdate').val(descriptionModel);
    $('#idVendorUpdate').val(codeVendor);
    $('#idSNDetUpdate').val(SNDetectable);
    $('#idModelDetUpdate').val(modelDetectable);

    $('#idProprieteUpdate').val(propriete);
    $('#idCodeModelUpdate').val(codeModel);


}

function update() {

    $(document).ready(function () {
        $('#idBtnUpdate').click(function () {
            var CodeModel = $('#idCodeModelUpdate').val();
            var description = $('#idDescriptionUpdate').val();
            var SNDetectable = parseInt($('#idSNDetUpdate').val());
            var modelDetectable = parseInt($('#idModelDetUpdate').val());
            var propriete = $('#idProprieteUpdate').val();
            var CodeVendor = parseInt($('#idVendorUpdate').val());
            var IdTypeDev = parseInt($('#idTypeDevUpdate').val());

            var modele = '{"codeModel":"' + CodeModel + '" ,"description":"' + description + '","sNDetectable":';
            modele += SNDetectable + ',"modelDetectable":' + modelDetectable + ',"codeVendor":' + CodeVendor;
            modele += ',"idTypeDev":' + IdTypeDev + ',"propriete":"' + propriete + '"}';

            $.ajax({
                url: 'https://localhost:44393/Model/AddModel',
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: modele,
                dataType: "json",
                success: function (data) {
                    alert("Les modifications sont enregistrés");

                    ViewModels();


                }
            });



        });

    });

}



function ViewModels() {
    $('#idTBody').empty();

    var IdTypeDev = parseInt($('#idTypeDevice').val());
    var CodeVendor = parseInt($('#idVendors').val());
    var SNDetectable = parseInt($('#idSNDetectable').val());
    var ModelDetectable = parseInt($('#idModelDetectable').val());

    var Propriete = $('#idPropriete').val().toString();
    var Description = $('#idDescription').val().toString();
    if ((Propriete === undefined || Propriete === null || Propriete.trim().length === 0)) {
        Propriete = "rien";
    }

    if ((Description === undefined || Description === null || Description.trim().length === 0)) {
        Description = "rien";
    }

    var critere = '{"IdTypeDev":' + IdTypeDev + ',"CodeVendor":' + CodeVendor + ',"SNDetectable":';
    critere += SNDetectable + ',"ModelDetectable":' + ModelDetectable + ',"Propriete":"' + Propriete;
    critere += '","Description":"' + Description + '"}';


    $.ajax({
        url: 'https://localhost:44393/Model/GetModels',
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: critere,
        dataType: "json",
       
        success: function (data) {
           
            $.each(data, function (index, val) {
                // var typeDev = new object();
                var ligne1 = "<tr>";
                ligne1 += "<td>";

                var typeDev = new Object();
                var SNDetectable2 = "Oui";
                var SN = 1;
                var MD = 1;
                var modelDetectable2 = "Oui";
                var numDev = val.idTypeDev;
                var CodeVendor = val.codeVendor;
                var descriptionDev = "";
                var nameVendor = "";


                $.ajax({
                    type: 'GET',
                    url: 'https://localhost:44393/TypeDevice/GetTypeDevice/' + numDev,
                    dataType: 'json',
                    success: function (response) {

                        typeDev.idTypeDev = response.idTypeDev;
                        descriptionDev = response.description;


                        if (val.snDetectable === false) {
                            SNDetectable2 = "Non";
                            SN = 0;

                        }
                        if (val.modelDetectable === false) {
                            modelDetectable2 = "Non";
                            MD = 0;
                        }

                        $.ajax({
                            type: 'GET',
                            url: 'https://localhost:44393/Vendor/GetVendor/' + CodeVendor,
                            dataType: 'json',
                            success: function (response2) {
                                nameVendor = response2.description;
                                ligne1 += "<a href=\"#\" id=\"idBtnUpdate\" class=\"btn-ajuster btn btn-default\" role=\"button\"";
                                ligne1 += " onclick =\"loadModel('" + descriptionDev + "','" + nameVendor + "','" + val.description + "',";
                                ligne1 += + SN + "," + MD + ",'" + val.propriete + "','" + val.codeModel + "'," + numDev + ",";
                                ligne1 += CodeVendor + ");\">Edit</a> </td>";
                                ligne1 += "<td>" + descriptionDev + "</td>";
                                ligne1 += "<td>" + nameVendor + "</td>";
                                ligne1 += "<td>" + val.description + "</td>";
                                ligne1 += "<td>" + SNDetectable2 + "</td>";
                                ligne1 += "<td>" + modelDetectable2 + "</td>";
                                ligne1 += "<td>" + val.propriete + "</td>";
                                ligne1 += "<input type=\"hidden\" value=\"" + val.codeModel + "\">";

                                ligne1 += "<input type=\"hidden\" value=\"" + numDev + "\">";
                                ligne1 += "<input type=\"hidden\" value=\"" + CodeVendor + "\">";


                                ligne1 += "</tr>";


                                $('#idTBody').append(ligne1);
                                sortTable();
                                
                            }
                        });

                    }
                });

            });
        }

    });
    
}


function sortTable() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("idModels");
    switching = true;
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
        //start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /*Loop through all table rows (except the
        first, which contains table headers):*/
        for (i = 1; i < (rows.length - 1); i++) {
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[0];
            y = rows[i + 1].getElementsByTagName("TD")[0];
            //check if the two rows should switch place:
            if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                //if so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}


function sortTable2(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("idModels");
    switching = true;
    //Set the sorting direction to ascending:
    dir = "asc";
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
        //start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /*Loop through all table rows (except the
        first, which contains table headers):*/
        for (i = 1; i < (rows.length - 1); i++) {
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            /*check if the two rows should switch place,
            based on the direction, asc or desc:*/
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    //if so, mark as a switch and break the loop:
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            //Each time a switch is done, increase this count by 1:
            switchcount++;
        } else {
            /*If no switching has been done AND the direction is "asc",
            set the direction to "desc" and run the while loop again.*/
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}