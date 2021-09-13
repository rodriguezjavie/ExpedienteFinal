    var counter = 1;
    $("body").on("click", "#btnAdd", function () {
        $('<tr> ' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__Medicine" name="MedicinesPrescriptions[' + counter + '].Medicine" type="text" value="" /> </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__UnitOfMeasure" name="MedicinesPrescriptions[' + counter + '].UnitOfMeasure" type="text" value="" />  </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__Dose" name="MedicinesPrescriptions[' + counter + '].Dose" type="text" value="" /> </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__Frequency" name="MedicinesPrescriptions[' + counter + '].Frequency" type="text" value="" /> </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__Administration" name="MedicinesPrescriptions[' + counter + '].Administration" type="text" value="" /> </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__TreatmentDuration" name="MedicinesPrescriptions[' + counter + '].TreatmentDuration" type="text" value="" /> </td>' +
            '<td><input class="form-control col-md-10 text-box single-line" id="MedicinesPrescriptions_' + counter + '__Indications" name="MedicinesPrescriptions[' + counter + '].Indications" type="text" value="" /> </td>' +
            '<td><input type="button" class="btn btn-warning" value="Quitar" onclick="Remove(this)" /></td>' +
            '</tr>').appendTo('#tableMed');
    counter++;
    return false;

        });

    function Remove(button) {
            var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("¿Desea borrar esta línea?")) {
                var table = $("#tableMed")[0];
    table.deleteRow(row[0].rowIndex);
            }
        };

