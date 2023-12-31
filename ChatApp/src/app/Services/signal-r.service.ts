import { Injectable } from '@angular/core';
import * as signalr from "@microsoft/signalr"
@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor() { }
  HubConnection!:signalr.HubConnection
  startConnection=()=>{


    this.HubConnection=new signalr.HubConnectionBuilder()
    .withUrl("https://localhost:7150/chat",{
      skipNegotiation:true,
      transport:signalr.HttpTransportType.WebSockets,
    })
    .withAutomaticReconnect()
    .build();

    this.HubConnection.
    start()
    .then(()=>{
      console.log("hub connection started")
    }).catch(Error=>console.log("error while starting connection"+Error))
  }
  stopConnection() {
    return this.HubConnection.stop();
  }
}
