import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-savings-graph',
  templateUrl: './savings-graph.component.html',
  styleUrls: ['./savings-graph.component.css']
})
export class SavingsGraphComponent implements OnInit {

  data: number[] = [];
  goal!: number;
  datetime!: string;
  percents: any[] = [];
  //isButtonVisible: any = true;

  constructor() { }

  ngOnInit(): void {
    this.data = [100, 200, 404, 350, 620, 760, 865, 765, 985, 1000, 500];
    this.goal = 1000;
    this.datetime = "DateTime"
    this.percents = [];

    for(let i=0; i<this.data.length; i++){
      var x = (this.data[i]/this.goal) * 100;
      this.percents.push(x);
    }
  }

  addBar(data: string | number, percents: any): void {
    let barIn = document.createElement("div");
    barIn.classList.add('bar-in');
    barIn.style.width = `${percents}%`;
    barIn.style.height = "100%";
    barIn.style.background = "#3f9c47";
    barIn.style.boxShadow = "2px 2px 2px grey";
    barIn.innerText = "$" + data;

    let barOut = document.createElement("div");
    barOut.classList.add('bar-out');
    barOut.style.height = "30px";
    barOut.style.margin = "5px 0";
    barOut.style.width = "80%";
    barOut.style.position = "relative";
    barOut.style.float = "left";
    barOut.appendChild(barIn);

    let addTime = document.createElement("div");
    addTime.classList.add('add-time');
    addTime.style.width = "20%";
    addTime.style.float = "right";
    addTime.style.marginTop = "10px";
    addTime.innerText = this.datetime;

    document.getElementById("chart-in")!.appendChild(barOut);
    document.getElementById("chart-in")!.appendChild(addTime);
  };

  displayBars(): void { {
    for(let i=0; i<this.data.length; i++){
      this.addBar(this.data[i], this.percents[i]);
    }

    (<HTMLInputElement> document.getElementById("creationButton"))!.disabled = true;
  }};
}