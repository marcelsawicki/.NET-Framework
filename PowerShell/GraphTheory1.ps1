function Add-Edge {
    param(
        [string]$Source,
        [string]$Target
    )
    $Script:edges += "$Source->$Target"
}

function New-Graph {
    param(
        [string]$Name,
        [scriptblock]$ScriptBlock
    )

    $Script:edges = @()

function Add-Edge {
    param(
        [string]$Source,
        [string]$Target
    )
    $Script:edges += "$Source->$Target"
}
& $ScriptBlock

@"
digraph $name {
    $Script:edges
}
"@

}
New-Graph G {
    ForEach($x in 1..15) {
        Add-Edge $x ($x*$x)
    }
} | .\dot.exe -Tpng -o .\test.png