

//Checkout için yazılan scrpitler başlangıç
var paymentMethod = document.getElementsByName("paymentmethod");
var cardInfo = document.getElementById("cardInfo");
var customText = document.getElementById("customText");

for (var i = 0; i < paymentMethod.length; i++) {
    paymentMethod[i].addEventListener("change", function () {
        if (this.id === "credit") {
            cardInfo.style.display = "";
            customText.style.display = "none";
        }
        else if (this.id === "eft") {
            cardInfo.style.display = "none";
            customText.style.display = "block";
            customText.innerText = "Hesap bilgilerimiz siparişiniz oluşturulduktan sonra tarafınıza mail olarak gönderilecektir.";
        }
    });
}

//Confirm delete için yazılan script, admin girişlerinde aktif.
function confirmDelete() {
    var result = confirm("Silmek istediğinize emin misiniz?");
    if (result) {
        return true;
    }
    else {
        return false;
    }
}