function DisplayFunction(){
    let x = document.getElementById("HideOrShow1");
    let y = document.getElementById("HideOrShow2");
    if (x.style.display == "none" && y.style.display == "none") {
      x.style.display = "block";
      y.style.display = "block";
    } else {
      x.style.display = "none";
      y.style.display = "none";
    }
}

function ShowHiddenForm(){
    let x = document.getElementById("FormHeader");
    let y = document.getElementById("Form");
    x.style.display = "block";
    y.style.display = "block";
}

function CalculateSum(){
    let firstNum = parseInt(document.getElementById("firstNum").value);
    let secondNum = parseInt(document.getElementById("secondNum").value);
    let sum = (firstNum + secondNum);
    document.getElementById("Sum").innerHTML = "The sum of " + firstNum + " and " + secondNum + " is: " + sum;
}