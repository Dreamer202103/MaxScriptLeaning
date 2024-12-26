use std::ffi::FromVecWithNulError;

fn main() {
    println!("Hello, world!");
    //变量默认是不可变的
    //要声明可变变量需要添加mut

    // let x: i32 = 5; //默认i32格式
    let x = 1;
    println!("The Value of x is {}", x);
    // x = 10; // 这会报错，因为x是不可变的
    // x = 10; //

    //shadowing
    //let声明的同名新变量，也是不可变的
    //let声明的同名新变量，它的类型可以与之前不同
    let x = x + 1;

    println!("The Value of x is {}", x);

    let spaces = "  ";
    let spaces = spaces.len();
    println!("string长度是：{}", spaces);
    //const常量声明的关键字
    const MAX_VAL: i32 = 100_000_000;
    print!("常量值是：{}",MAX_VAL);
    // 以下代码会报错，因为MAX_VAL是const常量
    // MAX_VAL = 100_000_001;

    // 以下代码也会报错，因为MAX_VALu32u32是const常量
    // const MAX_VALu32u32: u32 = 100_000_000;
    // MAX_VALu32u32 = 100_000_001;
    // const MAX_VALUu32u32 = 100_000_000;

    //数据类型
    //tuple的创建
    let tup: (i32, f64, u8) = (50, 6.2, 1);
    println!("The first element of the tuple is {}", tup.0);
    //可以使用模式匹配来结构（destructure）一个Tuple来获取元素值
    let (a, b, c) = tup;
    println!("The second element of the tuple is {}", b);
    print!("The third element of the tuple is {}",c);

    //变量声明


    // 数组类型
    //数组的声明[数据类型；长度]
    //如果想让你的数据存放在stack（栈）上而不是和安排（堆）上，或者想保证有固定的元素，这时使用数组更有好处
    let arr: [i32; 5] = [1, 2, 3, 4, 5];
    println!("The second element of the array is {}", arr[1]);

    //Vector
    

    // 字符类型
    let c = 'z';
    println!("The character is {}", c);

    // 布尔类型
    let b = true;
    println!("The boolean is {}", b);

    // 字符序列类型
    let s = "Hello, World!";
    println!("The length of '{}' is {}", s, s.len());

    // 字符串类型
    let mut str = String::from("Hello, ");
    str.push_str("World!");
    println!("{}", str);

    // array的创建
    let arr: [i32; 5] = [1, 2, 3, 4, 5];
    println!("The second element of the array is {}", arr[1]);

    // 字符类型
    let c = 'z';
    println!("The character is {}", c);

    // 布尔类型
    let b = true;
    println!("The boolean is {}", b);

    // 字符序列类型
    let s = "Hello, World!";
    println!("The length of '{}' is {}", s, s.len());

    // 字符串类型
    let mut str = String::from("Hello, ");
    str.push_str("World!");
    println!("{}", str);
}
