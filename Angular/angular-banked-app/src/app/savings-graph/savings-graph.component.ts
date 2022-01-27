import { Component, OnInit } from '@angular/core';
import { Goal } from '../Goal';


@Component({
  selector: 'app-savings-graph',
  templateUrl: './savings-graph.component.html',
  styleUrls: ['./savings-graph.component.css']
})
export class SavingsGraphComponent implements OnInit {

  data: number[] = [];
  graphData: number[] = []; //Remove once connection is complete
  goal!: number;
  savingsGoal: Goal[] = [];
  datetime!: string;
  percents: any[] = [];
  bankedService: any;
  //isButtonVisible: any = true;

  userId: string | any = localStorage.getItem("userid");

  constructor() { }

  ngOnInit(): void {
    this.data = [100, 200, 404, 350, 620, 760, 865, 765, 985, 1000, 500];
    //this.goal = 1000;
    this.datetime = "DateTime"
    this.percents = [];
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
      var x = (this.data[i]/this.goal) * 100;
      this.percents.push(x);
    }

    for(let i=0; i<this.data.length; i++){
      this.addBar(this.data[i], this.percents[i]);
    }

    (<HTMLInputElement> document.getElementById("inputGoal"))!.disabled = true;
    (<HTMLInputElement> document.getElementById("creationButton"))!.disabled = true;
  }};

  getGoal(): void
  {
      this.bankedService.getGraph(this.userId)
      .subscribe((retObject: Goal[]) => this.CheckGoalApi(retObject));
  }
  CheckGoalApi(retObject: Goal[]): void {
    this.savingsGoal = retObject;
  }

  getGraphData(): void
  {
      this.bankedService.getGraph(this.userId)
      .subscribe((retObject: number[]) => this.CheckGraphApi(retObject));
  }
  CheckGraphApi(retObject: Array<number>): void {
    this.graphData = retObject; //Change to this.data once connection is complete
  }

  exit()
  {
    location.reload();
  }
}