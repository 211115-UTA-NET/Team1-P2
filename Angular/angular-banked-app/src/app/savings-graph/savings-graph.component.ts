import { Component, OnInit } from '@angular/core';
import { Goal } from '../Goal';
import { BankedService } from '../banked.service';
import { GraphData } from '../GraphData';


@Component({
  selector: 'app-savings-graph',
  templateUrl: './savings-graph.component.html',
  styleUrls: ['./savings-graph.component.css']
})
export class SavingsGraphComponent implements OnInit {

  data: any[] = [];
  goal!: number;
  savingsGoal: Goal[] = [];
  datetime!: string;
  datetimeArr: any[] = [];
  percents: any[] = [];
  //isButtonVisible: any = true;

  userId: string | any = localStorage.getItem("userid");

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
    this.datetime = "DateTime"
    this.getGraphData();
  }

  addBar(data: string | number, percents: any, datetime: string): void {
    let barIn = document.createElement("div");
    barIn.classList.add('bar-in');
    barIn.style.width = `${percents}%`;
    barIn.style.height = "100%";
    if(percents == 100)
    {
      barIn.style.background = "#39cc45";
    }
    else
    {
      barIn.style.background = "#3f9c47";
    }
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
    addTime.innerText = datetime;

    document.getElementById("chart-in")!.appendChild(barOut);
    document.getElementById("chart-in")!.appendChild(addTime);
  };

  displayBars(): void { {

    for(let i=0; i<this.data.length; i++)
    {
      var date = new Date();
      date.setDate(date.getDate() + (7 * i));
      var newDate = date.toString().substring(0,11) + date.toString().substring(13, 16);
      this.datetimeArr.push(newDate);
    }

    for(let i=0; i<this.data.length; i++){
      var x = (this.data[i]/this.goal) * 100;
      if(x > 100)
      {
        this.percents.push(100);
      }
      else
      {
        this.percents.push(x);
      }
    }

    for(let i=0; i<this.data.length; i++){
      this.addBar(this.data[i], this.percents[i], this.datetimeArr[i]);
  }

    (<HTMLInputElement> document.getElementById("inputGoal"))!.disabled = true;
    (<HTMLInputElement> document.getElementById("creationButton"))!.disabled = true;
  }};

  // getGoal(): void
  // {
  //     this.bankedService.getGraph(this.userId)
  //     .subscribe((retObject: Goal[]) => this.CheckGoalApi(retObject));
  // }
  // CheckGoalApi(retObject: Goal[]): void {
  //   this.savingsGoal = retObject;
  // }

  getGraphData(): void
  {
      this.bankedService.getGraph(this.userId)
      .subscribe((retObject) => this.CheckGraphApi(retObject));
  }
  CheckGraphApi(retObject: any): void {
    for(let i=0; i<retObject.length; i++ )
    {
      this.data.push(retObject[i]);
    }
  }

  exit()
  {
    location.reload();
  }
}