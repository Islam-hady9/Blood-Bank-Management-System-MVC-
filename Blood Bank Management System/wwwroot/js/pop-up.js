var changeButton = document.querySelector('#change');
var dialog_1 = document.getElementById('dialog_1');
var dialog_1_button_Done = document.getElementById('Done');

var radio_1 = document.getElementById('radio_1');
var radio_2 = document.getElementById('radio_2');
var radio_3 = document.getElementById('radio_3');

changeButton.onclick = function() {
    dialog_1.showModal();
}

var choice = "";
dialog_1_button_Done.onclick = function() {
    dialog_1.close();
    if(radio_1.checked) {
        choice = 'Add';
    }
    else if(radio_2.checked) {
        language = 'Remove';
    }
    else {
        language = 'Delete';
    }
}