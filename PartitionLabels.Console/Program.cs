var s = Console.ReadLine();
while (true) {
    var solution = PartitionLabels.PartitionLabels.Solution(s);
    Console.WriteLine(String.Join(", ", solution));
    
    s = Console.ReadLine();
}
