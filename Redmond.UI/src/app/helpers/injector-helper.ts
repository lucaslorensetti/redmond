import { Injector } from '@angular/core';

export function simpleInjector(name: string, value: any): Injector {
  return Injector.create({
    providers: [{
      provide: name, useValue: value
    }]
  });
}
