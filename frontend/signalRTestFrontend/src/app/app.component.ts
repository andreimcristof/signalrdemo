import { Component } from '@angular/core';
import { HttpClient, HubConnection } from '@aspnet/signalr-client';
import { NgFor } from '@angular/common';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';
  messages : Array<string>;
  connection: HubConnection;
  newMessage: "";

  ngOnInit(){
    this.messages = new Array<string>();

    this.connection = new HubConnection(`http://localhost:50225/chat`);
    this.connection.on('send', data => {
        this.messages.push(data);
    });

    this.connection.start()
              .then(() => this.connection.invoke('send', 'Hello'));
    }

    onSubmit() {
      console.log(this.newMessage);
      this.connection.invoke('send', this.newMessage);
      this.newMessage = "";
    }
}
