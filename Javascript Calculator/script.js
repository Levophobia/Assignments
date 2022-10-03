const display=document.querySelector("#display");
const buttons = document.querySelectorAll("button");

buttons.forEach((button) => {
    button.onclick = () => {
        if(button.id == "clear"){
        display.innerText = "";
        }
        else if (button.id == "del"){
            let string = display.innerText.toString();
            display.innerText = string.substr(0, string.length -1);
        }        
        else if (display.innerText == "" && button.id == "equals"){
            display.innerText = "Error";
            setTimeout(() => (display.innerText = ""), 1000);
        }
        else if (display.innerText != "" && button.id == "equals"){
            display.innerText = eval(display.innerText);
        }
        else{
            display.innerText += button.id;
            console.log(display.innerText)
        }
    }
})