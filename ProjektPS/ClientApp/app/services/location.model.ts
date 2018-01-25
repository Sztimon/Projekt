export class Location {
    public id: number;
    public name: string;
    public counter: number;

    constructor(id: number, name: string, counter: number) {
        this.id = id;
        this.name = name;

        this.counter = counter;
    }
}