package com.lg;
import javax.persistence.*;


@Entity
@Table(name = "roles", indexes = {
        @Index(name = "name_idx", columnList = "name", unique = true)
})
public class Role {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(nullable = false, unique = true)
    private String name;

    //constructor
    public Role() {
    }
    public Role(Long id, String name) {
        this.id = id;
        this.name = name;
    }
    //getters and setters
    public Long getId() {
        return id;
    }
    public void setId(Long id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

}
