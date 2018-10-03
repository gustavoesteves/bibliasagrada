import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  messages: string[] = [];

  constructor() { }

  add(message: Object) {
    Object.values(message).map(values => {
      this.messages.push(values);
    });
  }

  clear() {
    this.messages = [];
  }
}
