using ChainOfResponsibility.Abstraction;
using ChainOfResponsibility.Enums;
using ChainOfResponsibility.Models;
using ChainOfResponsibility.Workers;

// step 1 - init

IWorker driver_one = new Driver_One();
IWorker driver_two = new Driver_Two();
IWorker builder = new Builder();
IWorker manager = new Manager();

// step 2 - bind
driver_one.SetNextMonitor(driver_two).SetNextMonitor(builder).SetNextMonitor(manager);

// step 3 - start

driver_one.Invoke(new Command {Type = TypeCommand.Order, Command = "Хочу новый дом!"});
driver_one.Invoke(new Command {Type = TypeCommand.Drive, Command = "Привезти материалы!"});
driver_one.Invoke(new Command {Type = TypeCommand.Build, Command = "Построить здание!"});
driver_one.Invoke(new Command {Type = TypeCommand.Offer, Command = "Купите новый дом!"});