process.env.UV_THREADPOOL_SIZE = 10;

let cr = require('crypto');

let cpu = require('os');

console.log(cpu.arch(), cpu.cpus(), cpu.platform())

let start = Date.now();

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('1:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('2:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('3:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('4:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('5:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('6:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('7:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('8:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('9:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('10:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('11:', Date.now() - start)
})

cr.pbkdf2('a','b',100000,512,'sha512', () => {
    console.log('12:', Date.now() - start)
})