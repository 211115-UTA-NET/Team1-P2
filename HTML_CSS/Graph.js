
//grades of students
const data = [100, 200, 404, 350, 620, 760, 865, 765, 985, 1000];
var goal = 1000;
var datetime = "DateTime"

const percents = [];

for(let i=0; i<data.length; i++){
    var x = (data[i]/goal) * 100;
    percents.push(x);
  }


//adds bars to the div element
const addBar = (data, percents) => {
  let barIn = document.createElement("div");
  barIn.classList.add("bar-in");
  barIn.style.width = `${percents}%`;
  barIn.innerText = "$" + data;

  let barOut = document.createElement("div");
  barOut.classList.add("bar-out");
  barOut.appendChild(barIn);

  let addTime = document.createElement("div");
  addTime.classList.add("add-time");
  addTime.innerText = datetime;
  
  
  document.getElementById("chart-in").appendChild(barOut);
  document.getElementById("chart-in").appendChild(addTime);
};

function displayBars() {
    for(let i=0; i<data.length; i++){
        addBar(data[i], percents[i]);
      }
    document.getElementById("creationButton").disabled = true;
};


