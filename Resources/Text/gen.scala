import java.io._

object Main{
  def main(args: Array[String]){
    val writer = new PrintWriter(new File("FullDeck.txt"));
    var count = 0
    for(i <- 0 to 2){
      for (j <- 0 to 2){
        for (k <- 0 to 2){
          for(l <- 0 to 2){
            writer.write(i.toString + "," + j.toString + "," + k.toString + "," + l.toString + "\n")
            count += 1
          }
        }
      }
    }
    println(count)
    writer.close()
  }
}

