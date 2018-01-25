import { Contact } from "./contact.model";

export class Vehicle {
    public id: number;
    public name: string;
    public isRegistered: boolean;
    public image: string;
    public contact: Contact;
    public lastUpdate: number;
    public features: string[];
    public description: string;
    public counter: number;

    constructor(id: number, name: string, isRegistered: boolean,
        image: string, contact: Contact, features: string[],
        counter: number, description: string, lastUpdate: number ) {
        this.id = id;
        this.name = name;
        this.isRegistered = isRegistered;
        this.image = image;
        this.contact = contact;
        this.lastUpdate = lastUpdate;
        this.features = features;
        this.description = description;
        this.counter = counter;
    }
}