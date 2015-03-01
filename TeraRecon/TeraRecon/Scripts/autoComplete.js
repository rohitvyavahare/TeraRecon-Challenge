$(function () {
    var d =[];
    console.log("in autocomplete");
    $("#autocomplete").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Label/AutoComplete',
                cache: false,
                dataType: 'json',
                data: {
                    term: $("#autocomplete").val()
                },
                success:                                  
                 function (data) {

                     document.getElementById("result").className = "hidden";
                     for (var x in data) { 
                         d.push({                             
                             "label": data[x].label,
                             "value": data[x].item
                         })
                     }                     
                     console.log(d);
                     response(d);
                 },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        },
        minLength: 2,        
        select: function (event, ui) {
            console.log(ui.item);
            document.getElementById("result").className = "";
            document.getElementById("item").innerHTML = "Item :"+ui.item.value;
            document.getElementById("label").innerHTML = "Label:"+ui.item.label;
            
        }
    });
});